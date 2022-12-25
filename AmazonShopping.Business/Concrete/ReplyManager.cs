using AmazonShopping.Business.Abstract;
using AmazonShopping.Business.Constants;
using AmazonShopping.Business.Validators;
using AmazonShopping.Core.Helpers.Result.Abstract;
using AmazonShopping.Core.Helpers.Result.Concrete.ErrorResult;
using AmazonShopping.Core.Helpers.Result.Concrete.SuccessResults;
using AmazonShopping.DataAcces.Abstract;
using AmazonShopping.Entities.Concrete;
using AutoMapper.Configuration.Annotations;
using FluentValidation.Results;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using AutoMapper;
using static AmazonShopping.Entities.DTOs.ContactDTO;
using AmazonShopping.DataAcces.Concrete.EntityFrameworkCore;

namespace AmazonShopping.Business.Concrete
{
    public class ReplyManager : IReplyService
    {
        private readonly IReplyDal _replyDal;
        private readonly IMapper _mapper;
        private readonly IContactDal _contactDal;
        public ReplyManager(IReplyDal replyDal, IMapper mapper, IContactDal contactDal)
        {
            _replyDal = replyDal;
            _mapper = mapper;
            _contactDal = contactDal;
        }

        public IDataResult<Reply> DeleteReply(int id)
        {
            try
            {
                var currentData = _replyDal.Get(x => x.Id == id);
                currentData.IsDeleted = true;
                _replyDal.Update(currentData);
                return new SuccessDataResult<Reply>(currentData);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Reply>(ex.Message);
            }
        }

        public IDataResult<IEnumerable<Reply>> GetReplies(string userId)
        {
            try
            {
                var values = _replyDal.GetAll(x=>x.UserId== userId && x.IsDeleted==false);
                if(values.Count()!=0)
                    return new SuccessDataResult<IEnumerable<Reply>>(values);
                return new ErrorDataResult<IEnumerable<Reply>>(Messages.CannotBeNull);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<Reply>>(ex.Message);
            }
        }

        public IDataResult<Reply> ReplyFeedback(ReplyDTO reply, string userId)
        {
            try
            {
                var mapper = _mapper.Map<Reply>(reply);

                //get user email
                var userMail = _contactDal.Get(x => x.Id == reply.contactId).Email;

                mapper.ContactId = reply.contactId;
                mapper.Content = reply.content;
                mapper.UserId = userId;
                mapper.Date = DateTime.Now;
                ReplyValidator validationRules = new ReplyValidator();
                ValidationResult result = validationRules.Validate(mapper);
                if (result.IsValid)
                {

                    var email = new MimeMessage();
                    email.From.Add(MailboxAddress.Parse("rufullayevilkin66@gmail.com"));
                    email.To.Add(MailboxAddress.Parse(userMail));
                    email.Subject = "Thanks for your feadback";
                    email.Body = new TextPart(TextFormat.Plain) { Text = mapper.Content };

                    // send email
                    using var smtp = new SmtpClient();
                    smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    smtp.Authenticate("rufullayevilkin66@gmail.com", "weuopfpeqruiqsbo");
                    smtp.Send(email);
                    smtp.Disconnect(true);

                    _replyDal.Add(mapper);
                    return new SuccessDataResult<Reply>(mapper);
                }
                return new ErrorDataResult<Reply>(Messages.ErrorMessage);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Reply>(ex.Message);
            }
        }
    }
}
