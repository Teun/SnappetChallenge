const PROXY_CONFIG = [
  {
    context: ["/RESTAPI"],
    target: "http://localhost:64700/",
    secure: false,
    changeOrigin: true,
    logLevel: "debug",
    changeOrigin: true,
    pathRewrite: { "^/RESTAPI": "" }
  }
];

module.exports = PROXY_CONFIG;
