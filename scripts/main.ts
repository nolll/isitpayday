import { createRoot } from "react-dom/client";
import { createElement } from "react";
import App from "./App";
import "./styles";
import "../images/favicon.png";
import "../images/money.jpg";

createRoot(document.getElementById("app")!).render(createElement(App));
