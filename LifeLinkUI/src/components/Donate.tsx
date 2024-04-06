import Button from './Button';
import DonateLogo from '../assets/images/donate.png';

const Donate = () => {
  return (
    <section className='bg-[#173153] text-white h-[270px] flex items-center justify-center'>
      <div className='flex gap-[6rem] mb-3'>
        <div className='flex items-center gap-x-3'>
          <img src={DonateLogo} alt='Donate Logo' width={200} height={95} />
          <p className='text-[2.1rem] font-bold w-[290px] text-center'>Your gift holds great power – donate today!</p>
        </div>
        <div className='flex items-center gap-x-3 w-[560px]'>
          <p className='text-[1.2rem]'>
            Contribute a tax-deductible donation and join the forefront of transformative healthcare, 
            where connections and compassion are reshaping the field of medicine.
          </p>
          <Button style='btnEffects donateBtn mb-14' content='Donate' />
        </div>
      </div>
    </section>
  );
}

export default Donate;
