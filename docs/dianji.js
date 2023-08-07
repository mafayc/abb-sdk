function dianji(data)
{
			var rwServiceResource = new XMLHttpRequest();
	rwServiceResource.open("POST", "/rw/panel/ctrlstate?action=setctrlstate", true, "Default User", "robotics");
			rwServiceResource.timeout = 10000;
			rwServiceResource.setRequestHeader('content-type','application/x-www-form-urlencoded');
	rwServiceResource.send(data);
		}