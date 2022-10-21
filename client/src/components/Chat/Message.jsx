export default function Message (props){
    return ( 
        <>
        <div className="message">
            {props.user}: {props.message} 
        </div>
        </>   
        
    )
    
}