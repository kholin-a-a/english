const BaseApiUrl = "http://localhost:5000";

export const Http = {
  get: (input) => {
    const url = BaseApiUrl + input;
    return fetch(url)
      .then(r => r.json())
  }
}
