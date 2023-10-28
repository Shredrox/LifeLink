import React from 'react'
import Link from 'next/link'
import { FiPhoneCall } from 'react-icons/fi'
import { AiOutlineMail } from 'react-icons/ai'
import { BsHeartPulse } from 'react-icons/bs'
import { IoIosArrowForward } from 'react-icons/io'
import { FaRegHospital } from 'react-icons/fa6'
import { BsNewspaper } from 'react-icons/bs'
 
const Footer = () => {
  return (
    <footer id='main-footer' className='bg-darkBlue text-white'>
       <section className=''>
          <nav className='px-[11%] pt-[1.3rem] pb-10 border-t border-white'>
            <section className='flex gap-6'>
                <Link href='/' className="flex items-center gap-[0.5rem]">
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
            <ul className='w-[25%] flex flex-col gap-4 mt-3'>
              <li>
                <Link href='/doctors' className='flex items-center justify-between px-4 h-[4rem] border-2 border-[#456FC7] rounded-md hover:border-white'>
                  <div className='flex gap-3 items-center'>
                    <svg className="w-9 h-9" xmlns="http://www.w3.org/2000/svg" fill="white" aria-hidden="true" viewBox="0 0 32 32" data-di-res-id="55efa386-cc834516" data-di-rand="1698486534070">
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
                <Link href='#' className='flex items-center justify-between px-4 h-[4rem] border-2 border-[#456FC7] rounded-md hover:border-white'>
                  <div className='flex gap-3 items-center'>
                    <FaRegHospital size={35} />
                    <span>Find a hospital</span>
                  </div>
                  <IoIosArrowForward size={15} />
                </Link>
              </li>
              <li>
                <Link href='#' className='flex items-center justify-between px-4 h-[4rem] border-2 border-[#456FC7] rounded-md hover:border-white'>
                  <div className='flex gap-3 items-center'>
                    <BsNewspaper size={35} />
                    <span>Sing up for our e-newsletters</span>
                  </div>
                  <IoIosArrowForward size={15} />
                </Link>
              </li>
            </ul>
            <ul className='mt-5 flex flex-col gap-3'>
              <li className='text-[1.25rem]'>
                <Link href='/about' className='hover:underline'>About LifeLink</Link>
                <IoIosArrowForward className='inline ml-2' size={20} />
              </li>
              <li>
                <Link href='#' className='hover:underline'>About this Site</Link>
              </li>
              <li>
                <Link href='#' className='hover:underline'>Contact Us</Link>
              </li>
              <li>
                <Link href='#' className='hover:underline'>Locations</Link>
              </li>
              <li>
                <Link href='#' className='hover:underline'>Healthcare Policy</Link>
              </li>
              <li>
                <Link href='#' className='hover:underline'>Newsletters</Link>
              </li>
            </ul>
          </nav>
          <section className='px-[9%]'>
            <ul className='flex gap-5 items-center text-[18px] pt-3 border-t border-[#224183]'>
                  <li className='hover:underline'>
                    <Link href='#'>Privacy Policy</Link>
                  </li>
                  <li className='text-[14px]'>|</li>
                  <li className='hover:underline'>
                    <Link href='#'>Terms and Conditions</Link>
                  </li>
                  <li className='text-[14px]'>|</li>
                  <li className='hover:underline'>
                    <Link href='#'>Do Not Share My Personal Information</Link>
                  </li>
                  <li className='text-[14px]'>|</li>
                  <li className='hover:underline'>
                    <Link href='#'>FAQ</Link>
                  </li>
                  <li className='text-[14px]'>|</li>
                  <li className='hover:underline'>
                    <Link href='#'>Donate</Link>
                  </li>
            </ul>
            <p className='pb-3 text-[#ebedeb] pt-2'>
              &copy; {new Date().getFullYear()} LifeLink Healthcare Company. All rights reserved.
            </p>
          </section>
        </section>
    </footer>
  )
}

export default Footer