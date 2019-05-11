showLoading("Завантаження калькурятора");

function showLoading(text) {
	const loadingText = document.querySelector(".start-loading--text");
	loadingText.textContent = text;
	document.addEventListener('DOMContentLoaded', function() {
			const loading = document.querySelector(".start-loading");
			loading.classList.add("start-loading__disabled");
		});
}
