import { FiPhoneCall } from 'react-icons/fi';
import { AiOutlineMail } from 'react-icons/ai';
import { BsHeartPulse } from 'react-icons/bs';
import { IoIosArrowForward } from 'react-icons/io';
import { GrTest } from "react-icons/gr";
import { BsNewspaper } from 'react-icons/bs';
import { Link } from 'react-router-dom';
 
const Footer = () => {
  return (
    <footer id='main-footer' className='bg-darkBlue text-white border-t border-white'>
      <section className='px-[11%] pt-[1.3rem] flex flex-col gap-y-5'>
        <section className='flex gap-6'>
          <Link to='/' className="flex items-center gap-[0.5rem]">
            <BsHeartPulse size={35} /> <span className='text-[2.25rem]'>LifeLink</span>
          </Link>
          <div className='flex flex-col justify-center text-[14px]'>
            <span>
              <FiPhoneCall className='inline' /> <span>+0885343008</span>      
            </span>
            <span>
              <AiOutlineMail className='inline' /> <span className='underline underline-offset-2'>lifelink@gmail.com</span>
            </span>
          </div>
        </section>
        <nav className='pb-10 flex gap-[12rem]'>
          <section className='flex flex-col gap-y-5 w-[30%]'>
            <ul className='w-full flex flex-col gap-4'>
              <li>
                <Link to='/doctors' className='footerCardLink'>
                  <div className='flex gap-3 items-center'>
                    <svg 
                      className="w-9 h-9" 
                      xmlns="http://www.w3.org/2000/svg" 
                      fill="white" 
                      aria-hidden="true" 
                      viewBox="0 0 32 32" 
                      data-di-res-id="55efa386-cc834516" 
                      data-di-rand="1698486534070">
                        <path d="M6,17a3,3,0,1,1,3-3A3,3,0,0,1,6,17Zm0-4a1,1,0,1,0,1,1A1,1,0,0,0,6,13Z"></path>
                        <path d="M19,18v4A6,6,0,0,1,7,22V19.05H5V22a8,8,0,0,0,16,0V18Z"></path>
                        <path d="M25,2V4h2v7a7,7,0,0,1-14,0V4h2V2H11v9h0a9,9,0,0,0,18,0V2Z"></path>
                    </svg>
                    <span>Find a medic</span>
                  </div>
                  <IoIosArrowForward size={15} />
                </Link>
              </li>
              <li>
                <Link to='#' className='footerCardLink'>
                  <div className='flex gap-3 items-center'>
                    <GrTest size={35} />
                    <span>Check your lab results</span>
                  </div>
                  <IoIosArrowForward size={15} />
                </Link>
              </li>
              <li>
                <Link to='#' className='footerCardLink'>
                  <div className='flex gap-3 items-center'>
                    <BsNewspaper size={35} />
                    <span>Sing up for our e-newsletters</span>
                  </div>
                  <IoIosArrowForward size={15} />
                </Link>
              </li>
            </ul>
            <ul className='flex flex-col gap-3 text-[14px]'>
              <li className='text-[1.25rem]'>
                <Link to='/about' className='hover:underline'>
                  About LifeLink 
                  <IoIosArrowForward className='inline ml-1' size={20} />
                </Link>
              </li>
              <li className='hover:underline cursor-pointer w-fit'>About this Site</li>
              <li className='hover:underline cursor-pointer w-fit'>Contact Us</li>
              <li className='hover:underline cursor-pointer w-fit'>Locations</li>
              <li className='hover:underline cursor-pointer w-fit'>Healthcare Policy</li>
              <li className='hover:underline cursor-pointer w-fit'>Newsletters</li>
            </ul>
          </section>
          <section className='mt-2 w-[25%] flex flex-col gap-y-5'>
            <ul className='flex flex-col gap-3 text-[14px]'>
              <li className='text-[1.25rem]'>
                <Link to='/doctors' className='hover:underline'>
                  Medical Professionals
                  <IoIosArrowForward className='inline ml-1' size={20} />
                </Link>
              </li>
              <li className='hover:underline cursor-pointer w-fit'>Clinical Trials</li>
              <li className='hover:underline cursor-pointer w-fit'>Refer a Patient</li>
              <li className='hover:underline cursor-pointer w-fit'>LifeLink Medical Policy</li>
            </ul>
            <ul className='flex flex-col gap-3 text-[14px]'>
              <li className='text-[1.25rem]'>
                <Link to='#' className='hover:underline'>
                  Businesses
                  <IoIosArrowForward className='inline ml-1' size={20} />
                </Link>
              </li>
              <li className='hover:underline cursor-pointer w-fit'>Executive Health Program</li>
              <li className='hover:underline cursor-pointer w-fit'>International Business Collaborations</li>
              <li className='hover:underline cursor-pointer w-fit'>Facilities</li>
              <li className='hover:underline cursor-pointer w-fit'>Supplier Information</li>
            </ul>
            <ul className='flex flex-col gap-3 text-[14px]'>
              <li className='text-[1.25rem]'>
                <Link to='#' className='hover:underline'>
                  Hiring
                  <IoIosArrowForward className='inline ml-1' size={20} />
                </Link>
              </li>
              <li className='hover:underline cursor-pointer w-fit'>Admissions Requirements</li>
              <li className='hover:underline cursor-pointer w-fit'>Intern Programs</li>
              <li className='hover:underline cursor-pointer w-fit'>Student & Faculty Programs</li>
            </ul>
          </section>
          <section className='ml-[5rem] w-[25%] mt-2 flex flex-col gap-y-5'>
            <ul className='flex flex-col gap-3 text-[14px]'>
              <li className='text-[1.25rem]'>
                <Link to='#' className='hover:underline'>
                  Researchers
                  <IoIosArrowForward className='inline ml-1' size={20} />
                </Link>
              </li>
              <li className='hover:underline cursor-pointer w-fit'>Research Faculty</li>
              <li className='hover:underline cursor-pointer w-fit'>Laboratories</li>
            </ul>
            <ul className='flex flex-col gap-3 text-[14px]'>
              <li className='text-[1.25rem]'>
                <Link to='#' className='hover:underline'>
                  International Patients
                  <IoIosArrowForward className='inline ml-1' size={20} />
                </Link>
              </li>
              <li className='hover:underline cursor-pointer w-fit'>Appointments</li>
              <li className='hover:underline cursor-pointer w-fit'>Financial Services</li>
              <li className='hover:underline cursor-pointer w-fit'>International Locations</li>
            </ul>
            <ul className='flex flex-col gap-3 text-[14px]'>
              <li className='text-[1.25rem]'>
                <Link to='#' className='hover:underline'>
                  Charities
                  <IoIosArrowForward className='inline ml-1' size={20} />
                </Link>
              </li>
              <li className='hover:underline cursor-pointer w-fit'>Community Health Needs Assessment</li>
              <li className='hover:underline cursor-pointer w-fit'>Financial Assistance</li>
            </ul>
          </section>
        </nav>
      </section>
      <section className='px-[9%]'>
        <ul className='flex gap-5 items-center text-[17px] pt-3 border-t border-[#224183]'>
          <li className='hover:underline cursor-pointer'>Privacy Policy</li>
          <span className='text-[12px]'>|</span>
          <li className='hover:underline cursor-pointer'>Terms and Conditions</li>
          <span className='text-[12px]'>|</span>
          <li className='hover:underline cursor-pointer'>Do Not Share My Personal Information</li>
          <span className='text-[12px]'>|</span>
          <li className='hover:underline cursor-pointer'>FAQ</li>
          <span className='text-[12px]'>|</span>
          <li className='hover:underline cursor-pointer'>Donate</li>
        </ul>
        <p className='text-[#ebedeb] pt-2 pb-5'>
          &copy; {new Date().getFullYear()} LifeLink Healthcare Company. All rights reserved.
        </p>
      </section>
    </footer>
  );
}

export default Footer;
