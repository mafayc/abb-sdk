
		function ZBX() {
			
			var rwServiceResource = new XMLHttpRequest();
			rwServiceResource.onreadystatechange = function ()
			{
				if (rwServiceResource.readyState == 4 && rwServiceResource.status == 200)
				{
					let obj = JSON.parse(rwServiceResource.responseText);
					//rwServiceResource.responseText;
					let service = obj._embedded._state[0];

					//document.write("---" + (service.rax_1 * 1).toFixed(2));
					document.getElementById("zuobiaoxi1").innerHTML = "工具名称：  " + service["tool-name"];
					document.getElementById("zuobiaoxi2").innerHTML = "wobj名称：  " + service["wobj-name"];
					document.getElementById("zuobiaoxi3").innerHTML = "运动模式：  " + service["jog-mode"];
					document.getElementById("zuobiaoxi4").innerHTML = "机器人模式：" + service["mode"];
					document.getElementById("zuobiaoxi5").innerHTML = "当前任务：  " + service["task"];
					document.getElementById("zuobiaoxi6").innerHTML = "负载模式：  " + service["payload-name"];
					document.getElementById("zuobiaoxi7").innerHTML = "轴数量：    " + service["axes"];
				}
			}


			rwServiceResource.open("GET","/rw/motionsystem/mechunits/ROB_1?json=1", true);
			rwServiceResource.send();
			//setInterval("ZBX()", 1000);
		}
