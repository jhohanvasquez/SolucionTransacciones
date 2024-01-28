const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:64159';

const PROXY_CONFIG = [
  {
    context: [
      "/api/rol",
      "/api/usuario",
      "/api/comercio",
      "/api/transaccion",
      "/api/dashboard",
      "/api/medioPago"
   ],
    target: target,
    secure: false
  }
]

module.exports = PROXY_CONFIG;
