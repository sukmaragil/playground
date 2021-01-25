/*
  This metric allows you to statistically calculate your custom value. It will give you minimum, maximum, average and percentiles, as is evident in the above screenshots for http_req* requests.
*/
import { Trend } from "k6/metrics";
import http from "k6/http";

var myTrend = new Trend("my_trend");

export default function () {
  let res = http.get("https://test.loadimpact.com/");
  myTrend.add(res.timings.sending + res.timings.receiving);
}