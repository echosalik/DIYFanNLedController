#include <LCD.h>
#include <LiquidCrystal_SR.h>

#define FAN1 3
#define FAN2 5

#define LEDR 6
#define LEDG 9
#define LEDB 10

#define LCD_DT 14
#define LCD_CK 15
#define LCD_EN 16

#define E_FAN1 0
#define E_FAN1 1

#define SAMPLE 100

#define E_RGB_START 2
#define E_RGB_END 502

LiquidCrystal_SR lcd(LCD_DT, LCD_CK, LCD_EN);

void setup() {
  Serial.begin(57600);
  Serial.println("System Started...");
  Serial.println("Setting Pins...");
  pinMode(FAN1, OUTPUT);
  pinMode(FAN2, OUTPUT);
  pinMode(LEDR, OUTPUT);
  pinMode(LEDG, OUTPUT);
  pinMode(LEDB, OUTPUT);
  Serial.println("LCD Settings...");
  lcd.begin(20, 4);
}

int led[2][6];
int led_type = 0;
int led_bright = 0;
int fan[2] = {50, 50};
int load[3];
int temp[2];
int gradient[SAMPLE][3];

bool fchange = false;
bool lchange = false;

void loop() {
  printCPUUsage(load[0]);
  printGPUUsage(load[1]);
  printRAMUsage(load[2]);
  printTemps(temp[0], temp[1]);
  if (fchange) {
    setFanSpeed();
  }
  if (led_type == 1) {
    rollColor();
  } else {
    analogWrite(LEDR, led_bright);
  }
}

void serialEvent() {
  Serial.readStringUntil('*');
  while (String main = Serial.readStringUntil('>')) {
    Serial.println("IN WHILE");
    Serial.println(main);
    if (main == "") {
      break;
    }
    String data;
    if (main == "leds") {
      lchange = true;
      int type = Serial.readStringUntil(':').toInt();
      led_type = type;
      if (type == 1) {
        for (int i = 0; i < 6; i++) {
          data = Serial.readStringUntil(',');
          if (i < 3) {
            led[0][i] = data.toInt();
          } else {
            led[0][i - 3] = data.toInt();
          }
          data = "";
        }
        generateGradient();
      } else {
        led_bright = Serial.readStringUntil(',').toInt();
      }
      Serial.readStringUntil(';');
    } else if (main == "fans") {
      fchange = true;
      for (int i = 0; i < 2; i++) {
        data = Serial.readStringUntil(',');
        fan[i] = data.toInt();
        data = "";
      }
      Serial.readStringUntil(';');
    } else if (main == "stat") {
      Serial.println(main);
      for (int i = 0; i < 2; i++) {
        data = Serial.readStringUntil(':');
        if (data == "load") {
          for (int j = 0; j < 3; j++) {
            data = Serial.readStringUntil(',');
            load[j] = data.toInt();
            data = "";
          }
          Serial.readStringUntil(';');
        } else if (data == "temp") {
          for (int j = 0; j < 2; j++) {
            data = Serial.readStringUntil(',');
            temp[j] = data.toInt();
            data = "";
          }
        }
        Serial.readStringUntil(';');
      }
    }
  }
}

void printCPUUsage(int usage) {
  int loc;
  int i;
  lcd.setCursor(0, 0);
  lcd.print("CPU% ");
  for (i = 1; i <= ceil(usage / 10); i++) {
    lcd.write(255);
  }
  for (i; i <= 10; i++) {
    lcd.print(" ");
  }
  lcd.print(" ");
  if (usage > 99) {
    lcd.print(usage);
  } else {
    lcd.print(" ");
    lcd.print(usage);
  }
  lcd.print("%");
}

void printGPUUsage(int usage) {
  int loc;
  int i;
  lcd.setCursor(0, 1);
  lcd.print("GPU% ");
  for (i = 1; i <= ceil(usage / 10); i++) {
    lcd.write(255);
  }
  for (i; i <= 10; i++) {
    lcd.print(" ");
  }
  lcd.print(" ");
  if (usage > 99) {
    lcd.print(usage);
  } else {
    lcd.print(" ");
    lcd.print(usage);
  }
  lcd.print("%");
}

void printRAMUsage(int usage) {
  int loc;
  int i;
  lcd.setCursor(0, 2);
  lcd.print("RAM% ");
  for (i = 1; i <= ceil(usage / 10); i++) {
    lcd.write(255);
  }
  for (i; i <= 10; i++) {
    lcd.print(" ");
  }
  lcd.print(" ");
  if (usage > 99) {
    lcd.print(usage);
  } else {
    lcd.print(" ");
    lcd.print(usage);
  }
  lcd.print("%");
}

void printTemps(int cputemp, int gputemp) {
  lcd.setCursor(0, 3);
  lcd.print("TEMP ");
  lcd.print("CPU ");
  if (cputemp < 100) {
    lcd.print(" ");
  }
  lcd.print(cputemp);
  lcd.print(" GPU ");
  if (gputemp < 100) {
    lcd.print(" ");
  }
  lcd.print(gputemp);
}

void generateGradient() {
  Serial.println("GENERATING GRADIENT...");
  int m[3];
  int r, g, b;
  m[0] = (led[1][0] - led[0][0]) / SAMPLE;
  m[1] = (led[1][1] - led[0][1]) / SAMPLE;
  m[2] = (led[1][2] - led[0][2]) / SAMPLE;
  for (int i = 0; i < SAMPLE; i++) {
    r = ceil(m[0] * i) + led[0][0];
    g = ceil(m[1] * i) + led[0][1];
    b = ceil(m[2] * i) + led[0][2];
    gradient[i][0] = r;
    gradient[i][1] = g;
    gradient[i][2] = b;
  }
  lchange = false;
  Serial.println("GRADIENT GENERATED...");
}

void rollColor() {
  Serial.println("ROLLING GRADIENT START...");
  for (int i = 0; i < SAMPLE; i++) {
    analogWrite(LEDR, gradient[i][0]);
    analogWrite(LEDG, gradient[i][1]);
    analogWrite(LEDB, gradient[i][2]);
    delay(50);
  }
  for (int i = SAMPLE - 1; i >= 0; i--) {
    analogWrite(LEDR, gradient[i][0]);
    analogWrite(LEDG, gradient[i][1]);
    analogWrite(LEDB, gradient[i][2]);
    delay(50);
  }
  Serial.println("ROLLING GRADIENT END...");
}

void setFanSpeed() {
  Serial.println("SETTING FAN SPEED");
  int speed1 = ((fan[0] * 256) / 100 ) - 1;
  int speed2 = ((fan[1] * 256) / 100 ) - 1;
  analogWrite(FAN1, speed1);
  analogWrite(FAN2, speed2);
  fchange = false;
}

//*stat>temp:39,38,;load:17,4,42,;fans>50,50,;
//*fans>10,10,;
