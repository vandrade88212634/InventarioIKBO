// sw.js

// Añade los archivos que deseas cachear aquí
const archivosACachear = [
    '/',
    '/index.html',
    '/styles.css',
    '/script.js',
    '/imagen.jpg'
  ];
  
  // Nombre del caché
  const nombreCache = 'app-cache';
  
  self.addEventListener('install', function(event) {
    // Instalación del Service Worker: añade los archivos al caché
    event.waitUntil(
      caches.open(nombreCache)
        .then(function(cache) {
          return cache.addAll(archivosACachear);
        })
    );
  });
  
  self.addEventListener('fetch', function(event) {
    // Intercepta las solicitudes de recursos y busca en el caché
    event.respondWith(
      caches.match(event.request)
        .then(function(response) {
          // Si se encuentra en caché, devuelve la respuesta en caché
          if (response) {
            return response;
          }
          // Si no está en caché, realiza la solicitud de red
          return fetch(event.request);
        })
    );
  });
  