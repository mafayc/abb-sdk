
		function IO() {
			
			var rwServiceResource = new XMLHttpRequest();
			rwServiceResource.onreadystatechange = function ()
			{
				if (rwServiceResource.readyState == 4 && rwServiceResource.status == 200) {
					let obj = JSON.parse(rwServiceResource.responseText);//rwServiceResource.responseText;
					let service = obj._embedded._state[0];//document.write("---" + (service.rax_1 * 1).toFixed(2));
					let i;
					for (i = 0; i < 50; i++)
					{
						service = obj._embedded._state[i];
						 document.getElementById("io"+i).innerHTML = service["_type"] + service["_title"] + service["name"] + service["type"] + service["lvalue"] + service["lstate"];
					}
				}
			}
			rwServiceResource.open("GET","/rw/iosystem/signals?json=1", true);
			rwServiceResource.send();
			//setInterval("IO()", 1000);
		}
