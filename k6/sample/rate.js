/* 
  This built-in metric keeps the rate between non-zero and zero/false values. For example if you add two false and one true value, the percentage becomes 33%.
  It can be used to keep track of the rate of successful request/responses and compare them with errors.
*/
import { Rate } from "k6/metrics";
import http from "k6/http";

var myRate = new Rate("my_rate");

export default function () {
  let res = http.get("https://test.loadimpact.com/404");
  myRate.add(res.error_code);
}