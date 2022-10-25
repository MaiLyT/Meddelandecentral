import "./App.css";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Map from "./components/Cleanning/Map";
import ChatInput from "./components/Chat/ChatInput";
import ChatWindow from "./components/Chat/ChatWindow";
import Rooms from "./components/Room/Rooms";
import Footer from "./components/Menu/Footer";
import Logo from "./components/Header/Logo";

export default function App(){
    return(
        <>
        <Logo />
        <Router>
            <Routes>
                <Route path="/" element={<Rooms />} />
                <Route path="/map" element={<Map />} />
                
            </Routes>
            <Footer />
        </Router>
        <ChatInput />
        <ChatWindow />
        </>
    )
}