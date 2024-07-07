import auth from "./dataComponents/auth.js";
import dropdown from "./dataComponents/dropdown.js";

import "../styles/index.scss";

import Alpine from "alpinejs";

Alpine.data("auth", auth);
Alpine.data("dropdown", dropdown);

Alpine.start();