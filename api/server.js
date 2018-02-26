var express = require('express'),
  app = express(),
  port = process.env.PORT || 9999;

app.listen(port);

app.route('/')
    .get((req, res) => {
        var start = Date.now();
        res.json({date: start});
    })

console.log('API server started on: http://localhost:' + port);
