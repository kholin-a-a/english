const BaseApiUrl = "http://localhost:5000";

export const Http = {
  get: (input) => {
    const url = apiUrl(input)
    return fetch(url).then(r => r.json())
  },

  post: (input, data) => {
    const url = apiUrl(input);

    return fetch(url, {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(data)
    })
    .then(parseResponse)
  },

  delete: (input, data) => {
    const url = apiUrl(input);

    return fetch(url, {
      method: "DELETE",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(data)
    })
    .then(parseResponse)
  }
}

const apiUrl = (path) => {
  return BaseApiUrl + path
}

const parseResponse = (response) => {
  const content = response.headers.get("Content-Type")

  if (!content) {
    return
  }

  if (content.includes("application/json")) {
    return response.json()
  }
}