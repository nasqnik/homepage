using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthApp.DTOs.Comment;
using AuthApp.Models;

namespace AuthApp.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                EnquiryId = commentModel.EnquiryId
            }; 
        }

        public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int enquiryId)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                EnquiryId = enquiryId
            }; 
        }

        public static Comment ToCommentFromUpdate(this UpdateCommentDto commentDto)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
            }; 
        }
    }
}