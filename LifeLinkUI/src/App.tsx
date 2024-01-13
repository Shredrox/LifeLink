import { Route, RouterProvider, createBrowserRouter, createRoutesFromElements } from "react-router-dom";
import MainLayout from "./layouts/MainLayout";
import Home from "./pages/Home";
import About from "./pages/About";

function App() {
  const router = createBrowserRouter(
    createRoutesFromElements(
     <Route element={<MainLayout/>}>
       <Route path="/" element={<Home/>}/>
       <Route path="/about" element={<About/>}/>
     </Route>
    )
  );

  return (
    <div>
      <RouterProvider router={router}/>
    </div>
  )
}

export default App
