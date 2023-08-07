
		function getRWSesource() {

			var rwServiceResource = new XMLHttpRequest();
			rwServiceResource.onreadystatechange = function ()
			{
				if (rwServiceResource.readyState == 4 && rwServiceResource.status == 200)
				{
					var obj = JSON.parse(rwServiceResource.responseText);
					var service = obj._embedded._state[0];
					document.getElementById("name").innerHTML= "1.名字："+service.name;
					document.getElementById("version").innerHTML= "2.版本"+service.rwversion;
					document.getElementById("versionname").innerHTML= "3.版本名称"+service.rwversionname;
					var index;

					for (index = 0;index<9; index++)
					{
						var option = obj._embedded._state[1].options[index];
						document.getElementById("li" + index).innerHTML =option.option; 

                       
					}
					

				}

			}

			rwServiceResource.open("GET", "/rw/system?json=1", true);
			rwServiceResource.send();
		}
