/*
    This metric lets you keep the last thing that is added to it. It’s a simple over-writable metric that holds its last added value.
    This metric can be used to retain the last value of any test item, be it response time, delay or any other user-defined value.
*/

import { Gauge } from "k6/metrics";
import http from "k6/http";

var myGauge = new Gauge("my_gauge");

export default function() {
  let res = http.get("https://test.loadimpact.com/404");
  myGauge.add(res.status);
}