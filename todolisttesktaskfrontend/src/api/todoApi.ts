import http from "./http-common";
import ITodoItem from "../Models/todoItemModel";

class TodoItemsAPI {
  getAll() {
    return http.get<Array<ITodoItem>>("/TodoItems");
  }

  get(id: number) {
    return http.get<ITodoItem>(`/TodoItems/${id}`);
  }

  create(data: ITodoItem) {
    return http.post<any>("/TodoItems", ({...data}));
  }

  delete(id: number) {
    return http.delete<any>(`/TodoItems/${id}`);
  }
}

export default new TodoItemsAPI;