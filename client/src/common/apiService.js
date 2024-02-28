import { ENDPOINT_URL } from "@/common/config";
import axios from "axios";
//import JwtService from "@/common/jwt.service";

/**
* Service to call HTTP request via Axios
*/
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

  /**
   * Send the GET HTTP request
   * @param resource
   * @param params
   * @returns {*}
   */
  get(resource, params) {
      this.setHeader();
      return axios.get(`${resource}/`, { params });
  },

  /**
   * Send the GET HTTP request
   * @param resource
   * @param params
   * @param config
   * @returns {*}
   */
  query(resource, params) {
    this.setHeader();
    return axios.get(resource, params).catch((error) => {
      throw new Error(`ApiService ${error}`);
    });
  },

  /**
   * Set the POST HTTP request
   * @param resource
   * @param params
   * @param config
   * @returns {*}
   */
  post(resource, params, config = null) {
    this.setHeader();
    return axios.post(`${resource}`, params, config);
  },

  /**
   * Send the UPDATE HTTP request
   * @param resource
   * @param slug
   * @param params
   * @returns {IDBRequest<IDBValidKey> | Promise<void>}
   */
  update(resource, slug, params) {
    this.setHeader();
    return axios.put(`${resource}/${slug}`, params);
  },

  /**
   * Send the PUT HTTP request
   * @param resource
   * @param params
   * @returns {IDBRequest<IDBValidKey> | Promise<void>}
   */
  put(resource, params) {
    this.setHeader();
    return axios.put(`${resource}`, params);
  },

  /**
   * Send the DELETE HTTP request
   * @param resource
   * @returns {*}
   */
  delete(resource) {
    this.setHeader();
    return axios.delete(resource);
  },
}

export default ApiService;