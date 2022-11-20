import {useState} from 'react'

function TodoForm({addTask}:{addTask:any}) {
    const [userInput, setUserInput] = useState<any>('')
    
    const handleChange = (e:any) => {
        setUserInput(e.currentTarget.value)
    }

    const handleSubmit = (e:any) => {
        e.preventDefault()
        addTask(userInput)
    }

    const handleKeyPress = (e:any) => {
        if(e.key === "Enter"){
            handleSubmit(e)
        }
    }

    return(
        <form onSubmit={handleSubmit}>
            <input
                value={userInput}
                type='text'
                onChange={handleChange}
                onKeyDown={handleKeyPress}
                placeholder="Write something.."
            />
            <button>Add</button>
        </form>
    )
}

export default TodoForm