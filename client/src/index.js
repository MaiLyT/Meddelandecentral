import ReactDOM from "react-dom/client";
import React from "react";
import "./index.css";
import App from "./App";
import Data from "./Data";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
    <Data>
        <App />
    </Data>
)