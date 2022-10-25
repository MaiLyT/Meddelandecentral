import  React, {useContext, useState, useRef}  from 'react'
import { AppContext } from '../../Data';

export default function ChatInput(){
    let savedUsername = localStorage.getItem('username');
    let initUsername = savedUsername !== null ? localStorage.getItem('username'):'';
    const [user, setUser] = useState(initUsername);
    const [message, setMessage] = useState('');

    const {sendMessage} = useContext(AppContext);

    const isUserProvided = user && user !== '';

    const onSubmit = (e) => {
        e.preventDefault();
        const isMessageProvided = message && message !== '';

        if(isUserProvided && isMessageProvided){
            sendMessage(user, message);
            setMessage('');
        }else{
            alert('Pls insert an user and a message');
        }
    }
    const onUserUpdate = (e) => {
        let currentname = e.target.value
        localStorage.setItem('username', currentname);
        setUser(currentname);
    }

    const onMessageUpdate= (e) => {
        setMessage(e.target.value);
    }

    return (
        <form onSubmit={onSubmit}>
            <label htmlFor="user">User:</label>
            <br />
            <input 
                placeholder='User name'
                id='user'
                name='user'
                value = {user}
                onChange ={onUserUpdate} />
            <br />
            
            <input autoFocus
                className='field'
                placeholder='  Message'
                label="Message" 
                type='text'
                id='message'
                name='message'
                value={message}
                onChange = {onMessageUpdate} />
            <button className='button'> Send </button>
        </form>
    )
}