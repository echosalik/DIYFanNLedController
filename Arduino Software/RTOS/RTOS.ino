#include <LCD.h>
#include <LiquidCrystal_SR.h>

#include <Arduino_FreeRTOS.h>

#define FAN1 3
#define FAN2 5

#define LEDR 6
#define LEDG 9
#define LEDB 10

#define LCD_DT 14
#define LCD_CK 15
#define LCD_EN 16

#define E_FAN1 0;
#define E_FAN1 1;

int led[2][6];
int led_type = 0;
int led_bright = 0;
int fan[2];
int load[3];
int temp[2];
int sample = 100;
int color[100][3];

LiquidCrystal_SR lcd(LCD_DT, LCD_CK, LCD_EN);

void TaskPrintLCD( void *pvParameters );
void TaskRGBCycle( void *pvParameters );
void TaskFanSpeed( void *pvParameters );

void setup() {
    //Serial.begin(115200);
    Serial.begin(57600);
    Serial.flush();
    pinMode(FAN1, OUTPUT);
    pinMode(FAN2, OUTPUT);
    pinMode(LEDR, OUTPUT);
    pinMode(LEDG, OUTPUT);
    pinMode(LEDB, OUTPUT);
    lcd.begin(20, 4);
    xTaskCreate(
    TaskPrintLCD
    ,  (const portCHAR *)"Print_To_LCD"  // A name just for humans
    ,  128  // This stack size can be checked & adjusted by reading the Stack Highwater
    ,  NULL
    ,  2  // Priority, with 3 (configMAX_PRIORITIES - 1) being the highest, and 0 being the lowest.
    ,  NULL );
    xTaskCreate(
    TaskRGBCycle
    ,  (const portCHAR *)"Cycle_RGB_Colors"  // A name just for humans
    ,  128  // This stack size can be checked & adjusted by reading the Stack Highwater
    ,  NULL
    ,  2  // Priority, with 3 (configMAX_PRIORITIES - 1) being the highest, and 0 being the lowest.
    ,  NULL );
     xTaskCreate(
    TaskFanSpeed
    ,  (const portCHAR *)"Set_Fan_Speed"  // A name just for humans
    ,  128  // This stack size can be checked & adjusted by reading the Stack Highwater
    ,  NULL
    ,  2  // Priority, with 3 (configMAX_PRIORITIES - 1) being the highest, and 0 being the lowest.
    ,  NULL );
}

void loop() {

}

void serialEvent(){
    Serial.readStringUntil('*');
    String main = Serial.readStringUntil('>');
    Serial.println(main);
    String data;
    if(main == "leds"){
        int type = Serial.readStringUntil(':').toInt();
        if(type == 1){
            for(int i=0; i<6; i++){
                data = Serial.readStringUntil(',');
                if(i < 3){
                    led[0][i] = data.toInt();
                }else{
                    led[0][i-3] = data.toInt();
                }
                data = "";
            }
            //generateGradient();
        }else{
            led_bright = Serial.readStringUntil(',').toInt();
        }
        Serial.readStringUntil(';');  
    }else if(main == "fans"){
        for(int i=0; i<2; i++){
            data = Serial.readStringUntil(',');
            fan[i] = data.toInt();
            data = "";
        }
        Serial.readStringUntil(';');
    }else if(main == "stat"){
        for(int i=0; i<2; i++){
            data = Serial.readStringUntil(':');
            if(data == "load") {
                for(int j=0; j<3; j++){
                    data = Serial.readStringUntil(',');
                    load[j] = data.toInt();
                    data = "";
                }
                Serial.readStringUntil(';');
            }else if(data == "temp"){
                for(int j=0; j<2; j++){
                    data = Serial.readStringUntil(',');
                    temp[j] = data.toInt();
                    data = "";
                }
            }
            Serial.readStringUntil(';');
        }
    }
}

void printCPUUsage(int usage){
    int loc;
    int i;
    lcd.setCursor(0,0);
    lcd.print("CPU% ");
    for(i = 1; i <= ceil(usage/10); i++){
        lcd.write(255);
    }
    for(i; i <= 10; i++){
        lcd.print(" ");
    }
    lcd.print(" ");
    if(usage > 99){
        lcd.print(usage);
    }else{
        lcd.print(" ");
        lcd.print(usage);
    }
    lcd.print("%");
}

void printGPUUsage(int usage){
    int loc;
    int i;
    lcd.setCursor(0,1);
    lcd.print("GPU% ");
    for(i = 1; i <= ceil(usage/10); i++){
      lcd.write(255);
    }
    for(i; i <= 10; i++){
      lcd.print(" ");
    }
    lcd.print(" ");
    if(usage > 99){
      lcd.print(usage);
    }else{
      lcd.print(" ");
      lcd.print(usage);
    }
    lcd.print("%");
}

void printRAMUsage(int usage){
    int loc;
    int i;
    lcd.setCursor(0,2);
    lcd.print("RAM% ");
    for(i = 1; i <= ceil(usage/10); i++){
      lcd.write(255);
    }
    for(i; i <= 10; i++){
      lcd.print(" ");
    }
    lcd.print(" ");
    if(usage > 99){
      lcd.print(usage);
    }else{
      lcd.print(" ");
      lcd.print(usage);
    }
    lcd.print("%");
}

void printTemps(int cputemp, int gputemp){
    lcd.setCursor(0,3);
    lcd.print("TEMP ");
    lcd.print("CPU ");
    if(cputemp < 100){
        lcd.print(" ");
    }
    lcd.print(cputemp);
    lcd.print(" GPU ");
    if(gputemp < 100){
        lcd.print(" ");
    }
    lcd.print(gputemp);
}

void generateGradient(){
    int m[3];
    int r, g, b;
    m[0] = (color[1][0] - color[0][0])/250;
    m[1] = (color[1][1] - color[0][1])/250;
    m[2] = (color[1][2] - color[0][2])/250;
    for(int i=0; i<sample; i++){
        r = ceil(m[0]*i) + color[0][0];
        g = ceil(m[1]*i) + color[0][1];
        b = ceil(m[2]*i) + color[0][2];
        color[i][0] = r;
        color[i][1] = g;
        color[i][2] = b;
    }
}

void rollColor(){
    for(int i=0; i<sample; i++){
        analogWrite(LEDR, color[i][0]);
        analogWrite(LEDG, color[i][1]);
        analogWrite(LEDB, color[i][2]);
        vTaskDelay(5);
    }
    for(int i=sample - 1; i >= 0; i--){
        analogWrite(LEDR, color[i][0]);
        analogWrite(LEDG, color[i][1]);
        analogWrite(LEDB, color[i][2]);
        vTaskDelay(5);
    }
}

void setFanSpeed(int fan[2]){
//    Serial.println(fan[0]);
//    Serial.println(fan[1]);
      analogWrite(FAN1, (fan[0]/100)*255);
      analogWrite(FAN2, (fan[1]/100)*255);
}

void TaskPrintLCD( void *pvParameters __attribute__((unused)) ){
    printCPUUsage(load[0]);
    printGPUUsage(load[1]);
    printRAMUsage(load[2]);
    printTemps(temp[0], temp[1]);
}

void TaskFanSpeed( void *pvParameters __attribute__((unused)) ){
    setFanSpeed(fan);
}

void TaskRGBCycle( void *pvParameters __attribute__((unused)) ){
    if(led_type == 1){
        rollColor();
        led_type = 0;
    }else{
        if(led_bright != analogRead(LEDR)){
            analogWrite(LEDR, led_bright);
        }
    }
}

