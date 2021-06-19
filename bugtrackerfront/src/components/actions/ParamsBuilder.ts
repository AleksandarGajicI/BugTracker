export class ParamsBuilder {
  private parameters: { [name: string]: any };
  private filters: { [name: string]: { property: string; value: any } };

  constructor() {
    this.parameters = {};
    this.filters = {};
  }

  addParameter(key: string, value: any) {
    this.parameters[key] = value;
    return this;
  }

  resetParameters() {
    this.parameters = {};
    return this;
  }

  addFilter(key: string, value: { property: string; value: any }) {
    this.filters[key] = value;
    return this;
  }

  resetFilters() {
    this.filters = {};
    return this;
  }

  makeUrlSearchParams(): URLSearchParams {
    let urlParams = new URLSearchParams();

    for (let key in this.parameters) {
      urlParams.append(key, this.parameters[key]);
    }

    let counter = 0;

    for (let key in this.filters) {
      console.log("in for");

      console.log(this.filters[key]);
      urlParams.append(
        "filters[" + counter + "].FilterProperty",
        this.filters[key].property
      );
      urlParams.append(
        "filters[" + counter + "].Value",
        this.filters[key].value
      );

      counter++;
    }

    return urlParams;
  }
}
