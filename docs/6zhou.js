
		function getJ() {
			
			var rwServiceResource = new XMLHttpRequest();
			rwServiceResource.onreadystatechange = function ()
			{
				if (rwServiceResource.readyState == 4 && rwServiceResource.status == 200)
				{
					var obj = JSON.parse(rwServiceResource.responseText);
					rwServiceResource.responseText;
					var service = obj._embedded._state[0];

					//document.write("---" + (service.rax_1 * 1).toFixed(2));
					document.getElementById("J1").innerHTML = "J1=" + (service.rax_1 * 1).toFixed(2);
					document.getElementById("J2").innerHTML = "J2=" + (service.rax_2 * 1).toFixed(2);
					document.getElementById("J3").innerHTML = "J3=" + (service.rax_3 * 1).toFixed(2);
					document.getElementById("J4").innerHTML = "J4=" + (service.rax_4 * 1).toFixed(2);
					document.getElementById("J5").innerHTML = "J5=" + (service.rax_5 * 1).toFixed(2);
					document.getElementById("J6").innerHTML = "J6=" + (service.rax_6 * 1).toFixed(2);
				}
			}


			rwServiceResource.open("GET", "/rw/motionsystem/mechunits/ROB_1/jointtarget?json=1", true,"Default User","robotics");
			rwServiceResource.send();
			//setInterval("getJ()", 1000);
		}
