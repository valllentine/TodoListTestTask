import {useEffect, useState} from 'react'
import TodoItem from './Components/TodoItem'
import TodoForm from './Components/TodoForm';
import ITodoItem from './Models/todoItemModel';
import todoItemsApi from './api/todoApi'

function App() {
  const [todoList, setTodos] = useState<Array<ITodoItem>>([])
  
  useEffect(() => {
    GetItems();
   }, []);

   const GetItems = ():any => {
    todoItemsApi.getAll()
    .then((response: any) => {
      setTodos(response.data);
      console.log(response.data);
    })
    .catch((e: Error) => {
      console.log(e);
      });
  };

  const addTask = (userInput:string) => {
    if(userInput){
      const newItem:ITodoItem ={
            id: todoList[todoList.length-1].id+1,
            task: userInput
    }
      setTodos(todoList=>([...todoList, newItem]))
      todoItemsApi.create(newItem)
    }
  }

  const removeTask = (id:any) => {
    setTodos([...todoList.filter((todo:any) => todo.id != id)])
    todoItemsApi.delete(id)
  }

  const handleToggle = (id:any) =>{
    setTodos([
      ...todoList.map((todo:any) => 
      todo.id === id ? {...todo, complete: !todo.complete} : {...todo }
      )
    ])
  }

  return (
    <div className="App">
      <header className='header'>
        <h1>ToDo List</h1>
      </header>
      <TodoForm addTask={addTask}/>
      <div className='current'>
        <h4>Current tasks:</h4>
      </div>
      
      {todoList.map((todo:any) => {
        return (
          <TodoItem
            todo={todo}
            key={todo.id} 
            toggleTask={handleToggle}
            removeTask={removeTask}
          />
        )
      })}
    </div>
  );
}

export default App;
