import auth from "./dataComponents/auth.js";

import "../styles/index.scss";

import Alpine from "alpinejs";

Alpine.data("auth", auth);

Alpine.start();