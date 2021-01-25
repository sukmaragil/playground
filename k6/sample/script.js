// Basic sample for k6 performance test
import { check } from "k6";
import http from "k6/http";

export default function() {
  let res = http.get("https://test.loadimpact.com/");
  check(res, {
    "is status 200": (r) => r.status === 200
  });
}