import { ENDPOINT_URL } from "@/common/config";
import axios from "axios";
//import JwtService from "@/common/jwt.service";

const ApiService = {
  init() {},

  setHeader() {
    //axios.defaults.headers.common["Authorization"] = JwtService.getToken();
    this.setbaseURL();
    axios.defaults.headers.common["Content-Language"] = "pt-BR";
  },

  setbaseURL() {
    axios.defaults.baseURL = ENDPOINT_URL;
  },

  get(resource, params) {
      this.setHeader();
      return axios.get(`${resource}/`, { params });
  },

  // query(resource, params) {
  //   this.setHeader();
  //   return axios.get(resource, params).catch((error) => {
  //     throw new Error(`ApiService ${error}`);
  //   });
  // },

  post(resource, params, config = null) {
    this.setHeader();
    return axios.post(`${resource}`, params, config);
  },

  update(resource, slug, params) {
    this.setHeader();
    return axios.put(`${resource}/${slug}`, params);
  },

  // put(resource, params) {
  //   this.setHeader();
  //   return axios.put(`${resource}`, params);
  // },

  delete(resource) {
    this.setHeader();
    return axios.delete(resource);
  },
}

export default ApiService;