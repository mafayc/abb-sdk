function kongzhi0() {
	var rwServiceResource = new XMLHttpRequest();
	rwServiceResource.onreadystatechange = function () {
		if (rwServiceResource.readyState == 4 && rwServiceResource.status == 200) {
			let obj = JSON.parse(rwServiceResource.responseText);//rwServiceResource.responseText;
			let service = obj._embedded._state[0];//document.write("---" + (service.rax_1 * 1).toFixed(2));
			let i;
			for (i = 0; i < 19; i++) {
				service = obj._embedded._state[i];
				document.getElementById("kongzhi0").innerHTML = "kz";
			}
		}
	}
	rwServiceResource.open("GET", "/rw/iosystem/signals?json=1", true);
	rwServiceResource.send();

}