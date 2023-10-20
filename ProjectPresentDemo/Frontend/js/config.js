const config = {

    get api_root() { return "http://localhost:5276/api" },

    get category_api() { return `${this.api_root}/Category` },

    get product_api() { return `${this.api_root}/Product`}
}

export default config

