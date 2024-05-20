function requestGET(route, param = "") {
  var method = "GET";
  var apiURL = "https://exercicios-api-rest.azurewebsites.net/api/atv/";
  var xhr = new XMLHttpRequest();
  xhr.withCredentials = true;

  xhr.addEventListener("readystatechange", function () {
    if (this.readyState === 4) {
      alert(this.responseText);
    }
  });

  xhr.open(method, apiURL + route + param);
  xhr.send();
}
