const x = "";

function getLocation() {
  try {
    navigator.geolocation.getCurrentPosition(showPosition);
  } catch {
    x = err;
  }
}

function showPosition(position) {
  x = "Latitude: " + position.coords.latitude + 
  "<br>Longitude: " + position.coords.longitude;
}

console.log(x);