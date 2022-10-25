import ClearIcon from '@mui/icons-material/Clear';
import ErrorOutlineIcon from '@mui/icons-material/ErrorOutline';
import { pink, green } from '@mui/material/colors';

export default function DescribeText (){
    return(
        <p className='describeText'><ClearIcon sx={{ fontSize: 30, color:green[700] }}/><span>: Cleaned room  </span> <ErrorOutlineIcon sx={{ fontSize: 30, color: pink[500]}}/> <span>: Need to be cleaned </span></p> 
    )
}