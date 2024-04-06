import { createBrowserRouter, Route, createRoutesFromElements } from 'react-router-dom';
import Home from '../pages/Home';
import About from '../pages/About';
import MainLayout from '../layouts/MainLayout';

export const MainRouter = createBrowserRouter(
  createRoutesFromElements(
    <Route>
      <Route element={<MainLayout />}>
        <Route path='/' element={<Home />} />
        <Route path='/about' element={<About />} />
      </Route>
    </Route>
  )
);
