
function comprobarRespuesta1(){
  const respuesta = document.getElementById("respuestaSala1").value.toLowerCase();
  const mensaje = document.getElementById("mensajeError");
  if (respuesta == "2 palos, 1 hierro" || respuesta == "1 hierro, 2 palos" || respuesta == "2 palos, 1 lingote de hierro" || respuesta == "1 lingote de hierro, 2 palos"){
    return true;
  }
  else{
    mensaje.innerHTML = "respuesta incorrecta";
    return false;
  }
}
function mensajeErrorLogin(){
  const mensaje = document.getElementById("mensajeError");
  mensaje.innerHTML = "usuario o contraseña incorrectos";
}
function pistaSala1(){
  const mensaje = document.getElementById("pista");
  mensaje.innerHTML = "es un objeto fino de madera y otro un mineral";
}
function comprobarRespuesta2(){
  const respuesta = document.getElementById("respuestaSala2").value.toLowerCase();
  const mensaje = document.getElementById("mensajeError2");
  if (respuesta == "pikachu, charmander, bulbasaur" || respuesta == "charmander, bulbasaur, pikachu" || respuesta == "bulbasaur, pikachu, charmander" || respuesta == "bulbasaur, charmander, pikachu" || respuesta == "charmander, pikachu, bulbasaur" || respuesta == "pikachu, bulbasaur, charmander"){
    return true;
  }
  else{
    mensaje.innerHTML = "respuesta incorrecta";
    return false;
  }
}
function pistaSala2(){
  const mensaje = document.getElementById("pista2");
  mensaje.innerHTML = "uno es amarilo, otro es rojo y el ultimo es verde";
}
function comprobarRespuesta3(){
  const respuesta = document.getElementById("respuestaSala3").value.toLowerCase();
  const mensaje = document.getElementById("mensajeError3");
  if (respuesta == "pisos picados, parque placentero, ciudad comercio" || respuesta == "pisos picados, ciudad comercio, parque placentero" || respuesta == "ciudad comercio, pisos picados, parque placentero" || respuesta == "ciudad comercio, parque placentero, pisos picados" || respuesta == "parque placentero, pisos picados, ciudad comercio" || respuesta == "parque placentero, ciudad comercio, parque placentero"){
    return true;
  }
  else{
    mensaje.innerHTML = "respuesta incorrecta";
    return false;
  }
}
function pistaSala3(){
  const mensaje = document.getElementById("pista3");
  mensaje.innerHTML = "P_ _ _ _  p_ _ _ _ _ _ , p _ _ _ _ _   p _ _ _ _ _ _ _ _ _, c _ _ _ _ _ c _ _ _ _ _ _ _ ";
}