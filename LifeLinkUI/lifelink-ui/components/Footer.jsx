import React from 'react'
import Link from 'next/link'
import { BsHeartPulse } from 'react-icons/bs'

const Footer = () => {
  return (
    <footer id='main-footer' className='bg-darkBlue text-white'>
       <div className="px-10">
                <Link href='/' className='flex items-center gap-[0.5rem]' title='LifeLink'>
                    <BsHeartPulse className='w-[25px] h-[25px]' /> <span className='text-[1.5rem]'>LifeLink</span>
                </Link>
            </div>
    </footer>
  )
}

export default Footer