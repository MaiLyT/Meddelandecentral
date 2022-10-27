import ClearIcon from '@mui/icons-material/Clear';
import CheckCircleOutlineIcon from '@mui/icons-material/CheckCircleOutline';
import { pink, green, blue } from '@mui/material/colors';

export default function DescribeText (){
    return(
        <p className='describeText'>            
            <CheckCircleOutlineIcon sx={{ fontSize: 30, color: green[700]}}/> 
            <span>: Clean </span>
            <ClearIcon sx={{ fontSize: 30, color:pink[400] }}/>
            <span>: Need to be cleaned  </span> 
        </p> 
    )
}