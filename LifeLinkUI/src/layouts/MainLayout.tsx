import Header from '../components/Header';
import Footer from '../components/Footer';
import Donate from '../components/Donate';
import { Outlet } from 'react-router-dom';

const MainLayout = () => {
  return (
    <>
      <Header />
      <main>
        <Outlet/>
        <Donate />
      </main>
      <Footer />
    </>
  );
}

export default MainLayout;
