import './Footer.css';
import HomeIcon from '@mui/icons-material/Home';
import MapIcon from '@mui/icons-material/Map';
import LogoutIcon from '@mui/icons-material/Logout';
import { pink, green, blue } from '@mui/material/colors';

import { useNavigate } from "react-router-dom";


export default function Footer(){

    let navigate = useNavigate();
    return(
        <div className="footer">
            <MapIcon fontSize="large" onClick={() => navigate("/map")} /> 
            <HomeIcon fontSize="large" onClick={() => navigate("/")}/>
            <LogoutIcon fontSize="large" />
        </div>
    )
}