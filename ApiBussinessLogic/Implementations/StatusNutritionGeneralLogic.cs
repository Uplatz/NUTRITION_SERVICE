using System.Collections.Generic;
using ApiBussinessLogic.Interfaces;
using ApiModel;
using ApiUnitWork;

namespace ApiBussinessLogic.Implementations
{
    public class StatusNutritionGeneralLogic:IStatusNutritionGeneralLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatusNutritionGeneralLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<StatusNutritionGeneral> GetList()
        {
            var statusNutritionGeneralList = _unitOfWork.ISnutrition.GetList();
            List<StatusNutritionGeneral> listCharged = new List<StatusNutritionGeneral>();
            foreach (var registerx in statusNutritionGeneralList)
            {
                var sizeValList = _unitOfWork.ISizeValue.GetList();
                List<SizeValue> listSizes=new List<SizeValue>();
                var kgValList = _unitOfWork.IKgValue.GetList();
                List<KgValue> listKgs=new List<KgValue>();
                var pReferenceList = _unitOfWork.IPersonalReference.GetList();
                List<PersonalReference> listpReferences=new List<PersonalReference>();
                foreach (var registery in sizeValList)
                {
                    if(registery.id==registerx.idSizeVal){listSizes.Add(_unitOfWork.ISizeValue.GetById(registery.id));}
                }
                foreach (var registerz in kgValList)
                {
                    if(registerz.id==registerx.idKgVal){listKgs.Add(_unitOfWork.IKgValue.GetById(registerz.id));}
                }
                foreach (var registera in pReferenceList)
                {
                    if(registera.id==registerx.idPreference){listpReferences.Add(_unitOfWork.IPersonalReference.GetById(registera.id));}
                }
                registerx.sizeValues = listSizes;
                registerx.kgValues = listKgs;
                registerx.pReferences = listpReferences;
                listCharged.Add(registerx);
            }
            return (listCharged);
        }
    }
}