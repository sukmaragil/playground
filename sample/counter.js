// This is a simple cumulative counter that can be used to measure any cumulative value like number of errors during the test.

import { Counter } from "k6/metrics";
import http from "k6/http";

var myErrorCounter = new Counter("my_error_counter");

export default function() {
  let res = http.get("https://test.loadimpact.com/404");
  if(res.status === 404) {
    myErrorCounter.add(1)
  }
}