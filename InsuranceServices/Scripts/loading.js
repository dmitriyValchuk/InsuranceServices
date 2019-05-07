showLoading("Загружаем калькулятор");

function showLoading(text) {
	const loadingText = document.querySelector(".loading--text");
	loadingText.textContent = text;
	document.addEventListener('DOMContentLoaded', function() {
			const loading = document.querySelector(".loading");
			loading.classList.add("loading__disabled");
		});
}
