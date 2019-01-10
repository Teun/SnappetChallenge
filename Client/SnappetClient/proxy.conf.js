const PROXY_CONFIG = [
  {
    context: ["/APIService"],
    target: "http://localhost:49735/",
    secure: false,
    changeOrigin: true,
    logLevel: "debug",
    changeOrigin: true,
    pathRewrite: { "^/APIService": "" }
  }
];

module.exports = PROXY_CONFIG;
