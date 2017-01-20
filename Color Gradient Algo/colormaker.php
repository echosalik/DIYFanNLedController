<?php
	$color["start"] = ["r"=>12, "g"=>200, "b"=>164];
	$color["end"]   = ["r"=>255, "g"=>255, "b"=>255];
	$sample = 1000;
	$gradient = [];
	//y = mx + c
	$m["r"] = ($color["end"]["r"] - $color["start"]["r"])/1000;
	$m["g"] = ($color["end"]["g"] - $color["start"]["g"])/1000;
	$m["b"] = ($color["end"]["b"] - $color["start"]["b"])/1000;

	$c["r"] = $color["end"]["r"];
	$c["g"] = $color["end"]["g"];
	$c["b"] = $color["end"]["b"];

	for ($i=1; $i < $sample; $i++) { 
		$r = $m["r"]*$i + $c["r"];
		$g = $m["g"]*$i + $c["g"];
		$b = $m["b"]*$i + $c["b"];
		$gradient[] = ["r"=>$r, "g"=>$g, "b"=>$b];
	}
?>
<!DOCTYPE html>
<html>
<head>
	<title>Data</title>
	<style type="text/css">
		div{
			display: inline-block;
			width: 10px;
			height: 100px;
			font-size: 0px;
			border: none;
			margin: 0px;
			padding: 0px;
		}
	</style>
</head>
<body>
<?php foreach ($gradient as $value): ?>
	<div style="background:rgb(<?=$value["r"]?>,<?=$value["g"]?>,<?=$value["b"]?>);"></div>
<?php endforeach; ?>
</body>
</html>