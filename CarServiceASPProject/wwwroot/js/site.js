// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let center = [55.796947, 49.133858];

function init() {
	let map = new ymaps.Map('map', {
		center: center,
		zoom: 17
	});

	let placemark = new ymaps.Placemark(center, {}, {

	});

	map.controls.remove('geolocationControl'); // удаляем геолокацию
	map.controls.remove('searchControl'); // удаляем поиск
	map.controls.remove('trafficControl'); // удаляем контроль трафика
	map.controls.remove('typeSelector'); // удаляем тип
	map.controls.remove('fullscreenControl'); // удаляем кнопку перехода в полноэкранный режим
	map.controls.remove('zoomControl'); // удаляем контрол зуммирования
	map.controls.remove('rulerControl'); // удаляем контрол правил
	map.behaviors.disable(['scrollZoom']); // отключаем скролл карты (опционально)

	map.geoObjects.add(placemark);
}

ymaps.ready(init);

function adminFunc() {
	var header = document.getElementById("header");
	var footer = document.getElementById("footer");
	header.classList.add("none");
	footer.classList.add("none");
}