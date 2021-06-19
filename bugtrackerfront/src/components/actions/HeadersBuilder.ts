export class HeadersBuilder {
  private headers: { [name: string]: any };

  constructor() {
    this.headers = {};
  }

  addHeader(key: string, value: any) {
    this.headers[key] = value;
    return this;
  }

  resetHeaders() {
    this.headers = {};
    return this;
  }

  getHeaders() {
    return this.headers;
  }
}
