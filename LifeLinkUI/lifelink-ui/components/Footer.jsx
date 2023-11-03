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
    <footer id='main-footer' className='bg-darkBlue text-white border-t border-white'>
       <section className='px-[11%] pt-[1.3rem] pb-6'>
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
            <nav className='pb-10 flex gap-[7rem]'>
              <section className='w-[30%]'>
                <ul className='w-[100%] flex flex-col gap-4 mt-3'>
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
                  <ul className='mt-5 flex flex-col gap-3 text-[14px]'>
                    <li className='text-[1.25rem]'>
                      <Link href='/about' className='hover:underline'>About LifeLink</Link>
                      <IoIosArrowForward className='inline ml-1' size={20} />
                    </li>
                    <li className='hover:underline cursor-pointer'>About this Site</li>
                    <li className='hover:underline cursor-pointer'>Contact Us</li>
                    <li className='hover:underline cursor-pointer'>Locations</li>
                    <li className='hover:underline cursor-pointer'>Healthcare Policy</li>
                    <li className='hover:underline cursor-pointer'>Newsletters</li>
                  </ul>
                </section>
                <section className='ml-6 w-[25%]'>
                  <ul className='mt-2 flex flex-col gap-3 text-[14px]'>
                    <li className='text-[1.25rem]'>
                      <Link href='/doctors' className='hover:underline'>Medical Professionals</Link>
                      <IoIosArrowForward className='inline ml-1' size={20} />
                    </li>
                    <li className='hover:underline cursor-pointer'>Clinical Trials</li>
                    <li className='hover:underline cursor-pointer'>Refer a Patient</li>
                    <li className='hover:underline cursor-pointer'>LifeLink Medical Policy</li>
                  </ul>
                  <ul className='mt-5 flex flex-col gap-3 text-[14px]'>
                    <li className='text-[1.25rem]'>
                      <Link href='#' className='hover:underline'>Businesses</Link>
                      <IoIosArrowForward className='inline ml-1' size={20} />
                    </li>
                    <li className='hover:underline cursor-pointer'>Executive Health Program</li>
                    <li className='hover:underline cursor-pointer'>International Business Collaborations</li>
                    <li className='hover:underline cursor-pointer'>Facilities</li>
                    <li className='hover:underline cursor-pointer'>Supplier Information</li>
                  </ul>
                  <ul className='mt-5 flex flex-col gap-3 text-[14px]'>
                    <li className='text-[1.25rem]'>
                      <Link href='#' className='hover:underline'>Hiring</Link>
                      <IoIosArrowForward className='inline ml-1' size={20} />
                    </li>
                    <li className='hover:underline cursor-pointer'>Admissions Requirements</li>
                    <li className='hover:underline cursor-pointer'>Intern Programs</li>
                    <li className='hover:underline cursor-pointer'>Student & Faculty Programs</li>
                  </ul>
                </section>
                <section className='ml-[5rem] w-[25%]'>
                  <ul className='mt-2 flex flex-col gap-3 text-[14px]'>
                    <li className='text-[1.25rem]'>
                      <Link href='#' className='hover:underline'>Researchers</Link>
                      <IoIosArrowForward className='inline ml-1' size={20} />
                    </li>
                    <li className='hover:underline cursor-pointer'>Research Faculty</li>
                    <li className='hover:underline cursor-pointer'>Laboratories</li>
                  </ul>
                  <ul className='mt-5 flex flex-col gap-3 text-[14px]'>
                    <li className='text-[1.25rem]'>
                      <Link href='#' className='hover:underline'>International Patients</Link>
                      <IoIosArrowForward className='inline ml-1' size={20} />
                    </li>
                    <li className='hover:underline cursor-pointer'>Appointments</li>
                    <li className='hover:underline cursor-pointer'>Financial Services</li>
                    <li className='hover:underline cursor-pointer'>International Locations</li>
                  </ul>
                  <ul className='mt-5 flex flex-col gap-3 text-[14px]'>
                    <li className='text-[1.25rem]'>
                      <Link href='#' className='hover:underline'>Charities</Link>
                      <IoIosArrowForward className='inline ml-1' size={20} />
                    </li>
                    <li className='hover:underline cursor-pointer'>Community Health Needs Assessment</li>
                    <li className='hover:underline cursor-pointer'>Financial Assistance</li>
                  </ul>
                </section>
              </nav>
          </section>
          <section className='px-[9%]'>
            <ul className='flex gap-5 items-center text-[17px] pt-3 border-t border-[#224183]'>
                  <li className='hover:underline cursor-pointer'>Privacy Policy</li>
                  <li className='text-[12px]'>|</li>
                  <li className='hover:underline cursor-pointer'>Terms and Conditions</li>
                  <li className='text-[12px]'>|</li>
                  <li className='hover:underline cursor-pointer'>Do Not Share My Personal Information</li>
                  <li className='text-[12px]'>|</li>
                  <li className='hover:underline cursor-pointer'>FAQ</li>
                  <li className='text-[12px]'>|</li>
                  <li className='hover:underline cursor-pointer'>Donate</li>
            </ul>
            <p className='pb-3 text-[#ebedeb] pt-2'>
              &copy; {new Date().getFullYear()} LifeLink Healthcare Company. All rights reserved.
            </p>
        </section>
    </footer>
  )
}

export default Footer