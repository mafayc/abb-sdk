



let rwServiceResource = new XMLHttpRequest();
let jishu = 0;
function cc() {
	/*获得计数器 */
	rwServiceResource.open("GET", "/rw/motionsystem?json=1", true);
	rwServiceResource.onreadystatechange = function () {
		if (rwServiceResource.readyState == 4 && rwServiceResource.status == 200) {
			let obj = JSON.parse(rwServiceResource.responseText);//rwServiceResource.responseText;
			let service = obj._embedded._state[0];//document.write("---" + (service.rax_1 * 1).toFixed(2));
			service = obj._embedded._state[0];
			jishu = service["change-count"];
			document.getElementById("xx").innerHTML = "cc:" + jishu;
		}
	}
	rwServiceResource.send();


	//rwServiceResource.open("GET", "/user?username=xyz&application=RobotStudio&location=&ulocale=Local", true);
	//rwServiceResource.send();

}
function us() {

	//rwServiceResource.open("POST", "/users", true, "Default User", "robotics");
	// rwServiceResource.timeout = 100;
	//rwServiceResource.setRequestHeader('content-type','username=xyz&application=RobotStudio&location=IN-BLR-XXXX&ulocale=local');
	rwServiceResource.open("POST", "/users", true, "Default User", "robotics");//初始化一个请求。
	rwServiceResource.timeout = 100;
	rwServiceResource.setRequestHeader('content-type', 'username=xyz&application=RobotStudio&location=IN-BLR-XXXX&ulocale=local');
	//rwServiceResource.send('application / x - www - form - urlencoded');
	if (rwServiceResource.DONE) {

		document.getElementById("xx").innerHTML = "us:77";
	}
}

function mot() {
	rwServiceResource.open("POST", "/rw/mastership/motion", true);
	rwServiceResource.timeout = 100;
	rwServiceResource.setRequestHeader('content-type', 'action=request');
	//rwServiceResource.send();
	document.getElementById("xx").innerHTML = "mot:?";
}
function dz() {

	rwServiceResource.open("POST", "/rw/motionsystem/mechunits/ROB_1?action=set&continue-on-en=1", true);
	rwServiceResource.timeout = 100;
	//rwServiceResource.setRequestHeader('content-type', 'jog-mode=AxisGroup1');
	rwServiceResource.setRequestHeader('content-type', 'jog-mode=AxisGroup1');
	//rwServiceResource.send();
	document.getElementById("xx").innerHTML = "dz:?";

}
function j1() {
	cc();
	rwServiceResource.open("POST", "/rw/motionsystem?action=jog", true);
	rwServiceResource.setRequestHeader('content-type', 'axis1=0&axis2=0&axis3=0&axis4=1000&axis5=0&axis6=0&ccount=' + jishu);
	//rwServiceResource.send(axis1 = 0,axis2=0 ,axis3=0,axis4=1000,axis5=0, axis6=0,ccount=323);
	setInterval("j1()", 10);
	document.getElementById("xx").innerHTML = "j1/" + jishu;
}
function j2() {
	cc();
	rwServiceResource.open("POST", "/rw/motionsystem?action=jog", true);
	rwServiceResource.setRequestHeader('content-type', 'axis1=0&axis2=0&axis3=0&axis4=0&axis5=1000.00&axis6=0&ccount=' + jishu);
	//rwServiceResource.send('axis1=-0&axis2=0&axis3=0&axis4=1000&axis5=0&axis6=0&ccount=' + jishu);
	setInterval('j2()', 200);
	document.getElementById("xx").innerHTML = "j2/" + jishu;

}