function showHideAllSections(action) {
	var tableElements = document.getElementsByTagName("table");
	var spanElements = document.getElementsByTagName("span");
	var imgElements = document.getElementsByTagName("img");
	if (action == "show") {
		for (i = 0; i < spanElements.length; i++) {
			if (spanElements[i].id.indexOf('Section') != -1) {
				spanElements[i].style.display = '';
			}
		}
		for (i = 0; i < tableElements.length; i++) {
			if (tableElements[i].id.indexOf('Section') != -1) {
				tableElements[i].style.display = '';
			}
		}
		for (i = 0; i < imgElements.length; i++) {
			if (imgElements[i].id.indexOf('Image') != -1) {
				imgElements[i].src = 'images/icon_minus.gif';
			}
		}
	} else {
		for (i = 0; i < spanElements.length; i++) {
			if (spanElements[i].id.indexOf('Section') != -1) {
				spanElements[i].style.display = 'none';
			}
		}
		for (i = 0; i < tableElements.length; i++) {
			if (tableElements[i].id.indexOf('Section') != -1) {
				tableElements[i].style.display = 'none';
			}
		}
		for (i = 0; i < imgElements.length; i++) {
			if (imgElements[i].id.indexOf('Image') != -1) {
				imgElements[i].src = 'images/icon_plus.gif';
			}
		}
	}
}

function showHideSection(name) {
	var image = document.getElementById(name + "Image");
	var section = document.getElementById(name + "Section");
	var displayStatus = section.style.display;

	if (displayStatus == 'none') {
		image.src = 'images/icon_minus.gif';
		section.style.display='';

		// Resize text area		
		if (name == 'LicenseText') {
			resizeTextarea('licText');
		}
	} else {
		image.src = 'images/icon_plus.gif';
		section.style.display='none';
	}
}

function showHideSectionNew(name) {
	var image = document.getElementById("Image" + name);
	var section = document.getElementById("Section" + name);
	var displayStatus = section.style.display;

	if (displayStatus == 'none') {
		image.src = 'images/icon_minus.gif';
		section.style.display='';
	} else {
		image.src = 'images/icon_plus.gif';
		section.style.display='none';
	}
}

function showHideSectionsNew(sections, myImageSection) {
	var myImage = document.getElementById("Image" + myImageSection);
	if (myImage.src.indexOf('images/icon_minus.gif') != -1) {
		myImage.src = 'images/icon_plus.gif';
		var names = sections.split(",");
		for (i = 0; i < names.length; i++) {
			var image = document.getElementById("Image" + names[i]);
			var section = document.getElementById("Section" + names[i]);
			image.src = 'images/icon_plus.gif';
			section.style.display='none';
		}
	} else {
		myImage.src = 'images/icon_minus.gif';
		var names = sections.split(",");
		for (i = 0; i < names.length; i++) {
			var image = document.getElementById("Image" + names[i]);
			var section = document.getElementById("Section" + names[i]);
			image.src = 'images/icon_minus.gif';
			section.style.display = '';
		}
	}
}

function showHideAll(action) {
	var spanElements = document.getElementsByTagName("span");
	var imgElements = document.getElementsByTagName("img");
	if (action == "show") {
		for (i = 0; i < spanElements.length; i++) {
			if (spanElements[i].id.indexOf('SectionCVE') != -1) {
				spanElements[i].style.display = '';
			}
			if (imgElements[i].id.indexOf('ImageCVE') != -1) {
				imgElements[i].src = 'images/icon_minus.gif';
			}
		}
	} else {
		for (i = 0; i < spanElements.length; i++) {
			if (spanElements[i].id.indexOf('SectionCVE') != -1) {
				spanElements[i].style.display = 'none';
			}
			if (imgElements[i].id.indexOf('ImageCVE') != -1) {
				imgElements[i].src = 'images/icon_plus.gif';
			}
		}
	}
}

function removeSelectedRows(rowType, componentId) {
	var inputElements = document.getElementsByTagName('input');
	var ids = "";
	var numElementsFound = 0;
	for (i = 0; i < inputElements.length; i++) {
		if (inputElements[i].checked) {
			if (numElementsFound > 0) {
				ids += "|";
			}
			ids += inputElements[i].id;
			document.getElementById('row-' + inputElements[i].id).style.display = 'none';
			numElementsFound++;
		}
	}

	if (rowType == "component") {
		createCookie("componentsToIgnore", ids, 30);
	} else if (rowType = "version") {
		createCookie("componentVersionsToIgnore-" + componentId.toString(), ids, 30);
	}
}

function showHideRemovedRows(action, rowType, componentId) {
	var currentCookieValue;
	if (rowType == "component") {
		currentCookieValue = readCookie("componentsToIgnore");
	} else if (rowType == "version") {
		currentCookieValue = readCookie("componentVersionsToIgnore-" + componentId);
	} else if (rowType == "both") {
		currentCookieValue = readCookie("componentsToIgnore");
		if (currentCookieValue != null && currentCookieValue != "null" && currentCookieValue != "undefined") {
			var ids = currentCookieValue.split("|");
			for (i = 0; i < ids.length; i++) {
				var row = "fieldset-" + ids[i];
				var element = document.getElementById(row);
				if (element) {
					element.style.display = 'none';
				}
			}
		}
		var allCookies = document.cookie.split(';');
		for (x = 0; x < allCookies.length; x++) {
			var cookieName = allCookies[x];
			while (cookieName.charAt(0) == ' ') {
				cookieName = cookieName.substring(1,cookieName.length);
			}
			cookieName = cookieName.substring(0, cookieName.indexOf("="));
			if (cookieName.indexOf("componentVersionsToIgnore") >= 0) {
				currentCookieValue = readCookie(cookieName);
				if (currentCookieValue != null && currentCookieValue != "null" && currentCookieValue != "undefined") {
					var ids = currentCookieValue.split("|");
					for (i = 0; i < ids.length; i++) {
						var row = "row-" + ids[i];
						var element = document.getElementById(row);
						if (element) {
							element.style.display = 'none';
						}
					}
				}	
			}
		}
	}
	if (rowType != "both" && currentCookieValue != null && currentCookieValue != "null" && currentCookieValue != "undefined") {
		var ids = currentCookieValue.split("|");
		for (i = 0; i < ids.length; i++) {
			var row = "row-" + ids[i];
			var element = document.getElementById(row);
			if (element) {
				if (action == "hide") {
					element.style.display = 'none';
				} else {
					element.style.display = '';
				}
			}
		}
		if (action == "show") {
			if (rowType == "component") {
				eraseCookie("componentsToIgnore");
			} else if (rowType = "version") {
				eraseCookie("componentVersionsToIgnore-" + componentId);
			}
/*
			var inputElements = document.getElementsByTagName('input');
			for (i = 0; i < inputElements.length; i++) {
				if (inputElements[i].checked) {
					inputElements[i].checked = false;
				}
			}
*/
		}
	}
}

function checkUncheckAll(element) {
	var e = document.getElementById(element);
	var inputElements = document.getElementsByTagName('input');
	for (i = 0; i < inputElements.length; i++) {
		if (e.checked) {
			inputElements[i].checked = true;
		} else {
			inputElements[i].checked = false;
		}
	}
}

function resizeTextarea(element) {
	var e = document.getElementById(element);
	e.style.height = 0;
	e.style.height = (e.scrollHeight + 5) + "px";
}